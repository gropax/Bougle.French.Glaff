pipeline {
  agent {
    label 'dotnet5'
  }
  
  stages {
    stage('Checkout') {
      steps {
        git(url: 'https://github.com/gropax/Bougle.French.Glaff', branch: 'master')
        sh 'ls'
        sh 'dotnet restore'
      }
    }

  }
}
