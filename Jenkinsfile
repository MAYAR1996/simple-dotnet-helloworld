pipeline {
    
    stages {
        stage('run') {
            steps {
                sh 'dotnet run'
            }
            
        }
        stage('Build') {
            steps {
                sh 'dotnet build'
            }
            }
    }
    }
#!/usr/bin/env groovy

pipeline {
    agent {
      label 'windows'
    }
  environment {
    MSBUILD = "C:\Program Files (x86)\Microsoft Visual Studio\2017\BuildTools\MSBuild\15.0\Bin"
    CONFIG = 'Release'
    PLATFORM = 'x64'
  }
  stages {
    stage('Build') {
        agent {
      label 'windows'
    }
      steps {
        bat "NuGet.exe restore your_project.sln"
        bat "\"${MSBUILD}\" your_project.sln /p:Configuration=${env.CONFIG};Platform=${env.PLATFORM} /maxcpucount:%NUMBER_OF_PROCESSORS% /nodeReuse:false"
      }
    }
  }
}
