#!/usr/bin/env groovy

pipeline {
      agent {
      label 'windows-slave'
    }
  environment {
    MSBUILD = 'C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Professional\\MSBuild\\Current\\Bin\\MSBuild'
    CONFIG = 'Release'
    PLATFORM = 'x64'
  }
  stages {
    stage('Build') {
      steps {
            bat 'wmic computersystem get name'
            bat 'dotnet new sln --force'
            bat 'dotnet sln test.sln add helloworld.csproj'
            //bat 'nuget restore SolutionName.sln'
            //bat "\"${tool 'MSBuild'}\" SolutionName.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
            bat "NuGet.exe restore test.sln"
            bat "\"${MSBUILD}\" test.sln /p:Configuration=${env.CONFIG};Platform=${env.PLATFORM} /maxcpucount:%NUMBER_OF_PROCESSORS% /nodeReuse:false"
      }
    }
        stage('Unit test'){
    bat "if not exist \"CodeCoverage\" mkdir CodeCoverage"
    bat "if not exist \"CodeCoverageHTMLReport\" mkdir CodeCoverageHTMLReport"

    def MSTest = tool 'MSTest14.0'
    dir('Tests/Printing.Services.Test/bin/Debug')
    {
        Printing = bat returnStatus: true, script: "OpenCover.Console.exe -returntargetcode -register:user -target:${MSTest}  -targetargs:\"/nologo /testcontainer:Printing.Services.Test.dll /resultsfile:\\\"%WORKSPACE%\\TestResults_Printing.${BUILD_NUMBER}.trx\\\"\" -mergebyhash -output:\"%WORKSPACE%\\CodeCoverage\\Printing_CodeCoverage.xml\""
    }

    step([$class: 'MSTestPublisher', testResultsFile:"**/*.trx", failOnError: true, keepLongStdio: true])

    bat "ReportGenerator.exe \"-reports:%WORKSPACE%\\CodeCoverage\\*.xml\" \"-targetdir:%WORKSPACE%\\CodeCoverageHTMLReport\" "

    publishHTML([allowMissing: false, alwaysLinkToLastBuild: false, keepAll: true, reportDir: "CodeCoverageHTMLReport", reportFiles: 'index.htm', reportName: "CodeCoverage"])
    // stop the build if a unit test fails
    if ( (Printing != 0)  ){
        error("unit test failed")
    }
}
        
  // stage('UnitTests') {
   //     steps {
  //          bat "nunit3-console.exe ${env.WORKSPACE}/<test>/bin/Release/<test>.dll --result=nunit3.xml"
 //       }
  //  }
  }
}
