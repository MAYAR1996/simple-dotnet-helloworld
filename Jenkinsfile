pipeline {
    agent any {
      label 'windows'
    }
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
