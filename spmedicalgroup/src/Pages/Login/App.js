import React, {Component} from 'react';
import fundo from '../../Assets/img/fundohospital.jpg';
import logo from '../../Assets/img/logo.png';
import '../../Assets/css/login.css';
import Axios from 'axios';

export default class App extends Component{

  constructor(){
    super();
    this.state ={
        email: '',
        senha: ''
    }
}

atualizaEstadoEmail(event){
    this.setState({email : event.target.value});
}
atualizaEstadoSenha(event){
    this.setState({senha : event.target.value});
}

fazerLogin(event){
    event.preventDefault();
    Axios.post('http://localhost:5000/api/login',{
        email: this.state.email,
        senha: this.state.senha
    })
    .then(data => {
        localStorage.setItem("spmg", data.data.token);
        this.props.history.push('/cadastro');
        console.log(data);
    })
    .catch(erro => {
        console.log(erro);
    })
}

  render(){
    return(
      <div>

      <section className="banner">
      <img src={fundo} alt="fundo sp"></img>

    <div className="fundo">
        <img src={logo} alt="logo"></img>
    </div>

    <h1>SP Medical Group</h1>

    <div className="logar">
        <h2>LOGIN</h2>

    <form onSubmit={this.fazerLogin.bind(this)}>

    <div className="emailInput">
           <input id="email" type="text"  placeholder="Insira seu Email" value={this.state.email} onChange={this.atualizaEstadoEmail.bind(this)} />
    </div>
    
    <div className="senhaInput">
            <input id="senha" type="text" placeholder="Insira sua Senha" value={this.state.senha} onChange={this.atualizaEstadoSenha.bind(this)}/>
    </div>
    
    <div className="botao_entrar">
                <input type="submit" value="Entrar"/>
    </div>
    </form>

    <div className="botao_cadastra">
                <input type="button" value="Cadastrar-se"/>
    </div>
    </div>

    </section>
      </div>
    )
  }
}