import React, {Component} from 'react';
import '../../Assets/css/listagem.css';
import logo3 from '../../Assets/img/logo.png';

export default class listara extends Component{
    
    render(){
        return(
            <div>
    <section className="banner3">
        <img src={logo3}></img>
        <h1>SP MEDICAL GROUP</h1>
    </section>

    <section className="listara">
        <div className="quadrado3">
            <ul>
                    <li>Prontuário</li>
                    <li>Médico</li>
                    <li>Data Da Consulta</li>
                    <li>Situação</li>
                    <li>Descrição</li>
                </ul>
    </div>

    <div className="quadrado4">
        <h2>Lista Das Consultas</h2>
    </div>
    </section>
            </div>
        )
    }
}