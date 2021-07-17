pipeline {
  agent any
  stages {
    stage('Checkout') {
      steps {
        git(url: 'https://github.com/gropax/Bougle.French.Glaff', branch: 'master')
        sh 'dotnet restore'
      }
    }

  }
}