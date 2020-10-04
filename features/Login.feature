#language: pt-br


Funcionalidade: Login
	Como usuario cadastrado
	Desejo realizar o login no sistema
	para gerenciar minhas issues


@loginsucesso
Cenário: Login com sucesso
	Dado que estou na tela de login
	Quando eu preencho os campos de usuario e senha
	| usuario      | senha      |
	| raquel.dutra | gabi162010 |
	E clico em entrar
	Então sou direcionado para a tela principal

@loginInvalido
Cenário: Login invalido
	Dado que estou na tela de login
	Quando eu preencho os campos de usuario e senha com dados invalidos
	| usuario      | senha      |
	| raquel.dutra | senhainvalida |
	E clico em entrar
	Então vejo uma mensagem de usuario ou senha incorretos
	

@LoginEmBRanco
Cenário: Login em branco
	Dado que estou na tela de login
	Quando eu não preencho os campos de usuario e senha
	| usuario      | senha      |
	|		       |		    |
	E clico em entrar
	Então vejo uma mensagem de usuario ou senha incorretos
	