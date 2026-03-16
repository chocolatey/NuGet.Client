import jetbrains.buildServer.configs.kotlin.v2019_2.*
import jetbrains.buildServer.configs.kotlin.v2019_2.buildSteps.nuGetPublish
import jetbrains.buildServer.configs.kotlin.v2019_2.buildSteps.powerShell
import jetbrains.buildServer.configs.kotlin.v2019_2.triggers.vcs
import jetbrains.buildServer.configs.kotlin.v2019_2.buildFeatures.pullRequests

project {
    buildType(ChocolateyNugetClient)
}

object ChocolateyNugetClient : BuildType({
    name = "Build"

    templates(AbsoluteId("SlackNotificationTemplate"))

    artifactRules = """
        +:artifacts/nupkgs/*.nupkg
        -:artifacts/nupkgs/*.symbols.nupkg
        -:artifacts/nupkgs/*-beta.nupkg
        -:artifacts/nupkgs/*-alpha.nupkg
        -:artifacts/nupkgs/*-rc.nupkg
        -:artifacts/nugkgs/*-rtm*.nupkg
    """.trimIndent()

    vcs {
        root(DslContext.settingsRoot)

        branchFilter = """
            +:*
        """.trimIndent()
    }

    steps {
        powerShell {
            name = "Prerequisites"
            scriptMode = script {
                content = """
                    # Install Chocolatey Requirements
                    if ((Get-WindowsFeature -Name NET-Framework-Features).InstallState -ne 'Installed') {
                        Install-WindowsFeature -Name NET-Framework-Features
                    }

                    choco install visualstudio2022-workload-manageddesktopbuildtools visualstudio2022-workload-visualstudioextensionbuildtools visualstudio2022-component-texttemplating-buildtools --confirm --no-progress

                    exit ${'$'}LastExitCode
                """.trimIndent()
            }
        }

        powerShell {
            name = "Configure .NET and other dependencies"
            scriptMode = file {
                path = "configure.ps1"
            }
        }

        powerShell {
            name = "Build"
            scriptMode = script {
                content = """
                    ${'$'}branchName = '%teamcity.build.branch%'

                    if ( ${'$'}branchName -eq 'develop' ) { ${'$'}releaseLabel = 'alpha' }
                    elseif ( ${'$'}branchName -eq 'master' ) { ${'$'}releaseLabel = 'rc' }
                    elseif ( ${'$'}branchName.StartsWith('release') ) { ${'$'}releaseLabel = 'beta' }
                    elseif ( ${'$'}branchName.StartsWith('hotfix') ) { ${'$'}releaseLabel = 'beta' }
                    elseif ( ${'$'}branchName.StartsWith('tags') ) { ${'$'}releaseLabel = 'rtm' }
                    elseif ( ${'$'}branchName.StartsWith('proj') ) { ${'$'}releaseLabel = 'alpha' }
                    elseif ( ${'$'}branchName.StartsWith('bugfix') ) { ${'$'}releaseLabel = 'beta' }
                    elseif ( ${'$'}branchName.StartsWith('pull') ) { ${'$'}releaseLabel = 'pr' }

                    .\build.ps1 -CI -SkipUnitTest -ChocolateyBuild -BuildNumber %build.counter% -ReleaseLabel ${'$'}releaseLabel -BuildDate (Get-Date -Format "yyyyMMdd")
                """.trimIndent()
            }
        }

        powerShell {
            conditions {
                doesNotContain("teamcity.build.branch", "pull")
                doesNotContain("teamcity.build.branch", "feature")
            }
            name = "Publish NuGet Packages"
            scriptMode = script {
                content = """
                    ${'$'}files=Get-ChildItem "artifacts/nupkgs" | Where-Object {${'$'}_.Name -like "*.nupkg" -and ${'$'}_.Name -notlike "*symbols*" -and ${'$'}_.Name -notlike "*-beta.nupkg" -and ${'$'}_.Name -notlike "*-alpha.nupkg" -and ${'$'}_.Name -notlike "*-rc.nupkg" -and ${'$'}_.Name -notlike "*-rtm-*" -and ${'$'}_.Name -notlike "*-rc-*" -and ${'$'}_.Name -notlike "*-pr.nupkg" -and ${'$'}_.Name -notlike "*-pr-*"}

                    foreach (${'$'}file in ${'$'}files) {
                      NuGet push -Source '%env.NUGETDEVPUSH_SOURCE%' -ApiKey '%env.NUGETDEVPUSH_API_KEY%' "${'$'}(${'$'}file.FullName)"
                    }
                """.trimIndent()
            }
        }
    }

    triggers {
        vcs {
            branchFilter = ""
        }
    }

    features {
        pullRequests {
            provider = github {
                authType = token {
                    token = "%system.GitHubPAT%"
                }
            }
        }
    }
})
