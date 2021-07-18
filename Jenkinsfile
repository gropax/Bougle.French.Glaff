pipeline {
  agent {
    label 'dotnet5'
  }
  
  stages {
    stage('Checkout') {
      steps {
        git(url: 'https://github.com/gropax/Bougle.French.Glaff', branch: 'master')
      }
    }
    
    stage('Build') {
      steps {
        sh 'dotnet restore Bougle.French.Glaff.sln'
        sh 'dotnet build -c Release Bougle.French.Glaff.sln'
      }
    }
    
    stage('Tests') {
      steps {
        sh 'dotnet test -c Release Bougle.French.Glaff.sln'
      }
    }
  }
}
