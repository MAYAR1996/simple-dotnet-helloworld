#!/usr/bin/env groovy

pipeline {
      agent {
      label 'windows-slave'
    }
  environment {
    MSBUILD = 'C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Professional\\MSBuild\\Current\\Bin\\MSBuild'
    CONFIG = 'Release'
    PLATFORM = 'x64'
    MSTest = tool 'MSTest14.0'
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
    stage('Unit test')
{
   
        bat 'cd Tests/Printing.Services.Test/bin/Debug'
    
        bat "${MSTest} /testcontainer:Printing.Services.helloworld.dll /resultsfile:Results.trx"
    
    step([$class: 'MSTestPublisher', testResultsFile:"**/*.trx", failOnError: true, keepLongStdio: true])
}
      stage('UnitTests'){
            steps {
            bat'dotnet new nunit --force'
            bat returnStatus: true, script: "\"C:/Program Files/dotnet/dotnet.exe\" test \"${workspace}/test.sln\" --logger \"trx;LogFileName=unit_tests.xml\" --no-build"
            //step([$class: 'MSTestPublisher', testResultsFile:"**/unit_tests.xml", failOnError: true, keepLongStdio: true])
            nunit testResultsPattern: 'unit_tests.xml'        
                  
            }
        
        
        }
        
  }
}
