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
              def MSTest = tool 'MSTest14.0'
              dir('Tests/Printing.Services.helloworld/bin/Debug')
              {
                bat "${MSTest} /testcontainer:Printing.Services.helloworld.dll /resultsfile:Results.trx"
              }
            }
        
  // stage('UnitTests') {
   //    steps {
  //         bat "nunit3-console.exe ${env.WORKSPACE}/<test>/bin/Release/<test>.dll --result=nunit3.xml"
  //     }
 //  }
  }
}
