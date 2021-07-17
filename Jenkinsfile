pipeline {
  agent {
    label 'windows'
  }
  
  stages {
    stage('Checkout') {
      steps {
        git(url: 'https://github.com/gropax/Bougle.French.Glaff', branch: 'master')
        bat 'dotnet restore'
      }
    }

  }
}
