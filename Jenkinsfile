pipeline {
    agent any
   //    label 'android-poc-slave'
    stages {
        stage('Build') {
            steps {
                sh 'cd /var/lib/jenkins/workspace/dotnet-mayar-pipeline/samples/helloworld'
                sh 'dotnet run'
            }
        }
    }}
