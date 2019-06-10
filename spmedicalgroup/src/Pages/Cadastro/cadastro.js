import React, { Component } from 'react';
import logo2 from '../../Assets/img/logo.png';
import '../../Assets/css/cadastro.css';

export default class Cadastrar extends Component{

    constructor(){
        super();

        this.state={
            nmUsuario: '',
            dsSenha: '',
            dsEmail: '',
            numTelefone: '',
            idClinica: '',
            idTipoUsuario: ''
        }
    }

    render() {
        return(
    <div>
    <section className="banner2">
        <img src={logo2}></img>
        <h1>SP MEDICAL GROUP</h1>
    </section>

    <section className="cadastrar">
    <div className="atendimento">
        <h2>Cadastro Da Consulta</h2>

        <div className="quadrado">

            <div className="prontuarioInput">
                <label>Prontuário</label>
                <input id="prontuario" type="text" />
            </div>

            <div className="medicoInput">
                <label>Médico</label>
                <input id="medico" type="text" />
            </div>

            <div className="dataInput">
                <label>Data Da Consulta</label>
                <input id="data" type="DateTime-Local" />
            </div>

            <div className="situacaoInput">
                <label>Situação</label>
                <input id="situacao" type="text" />
            </div>

            <div className="descricaoInput">
                <label>Descrição</label>
                <input id="descricao" type="text" />
            </div>

            <div className="botaoenviar">
                <input type="submit" value="Entrar"/>
    </div>
        </div>
    </div>
</section>
            </div>
        )
    }
}