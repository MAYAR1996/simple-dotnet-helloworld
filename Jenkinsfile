pipeline {
    agent any
   //    label 'android-poc-slave'
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
    }}
