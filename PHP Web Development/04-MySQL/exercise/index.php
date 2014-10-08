<?php
$pageTitle = 'Потребителски вход';
include('include/header.php');
include('HTML/login.html');

if(!(isset($_SESSION['username']))){
	if($_POST){
		
		$username = trim($_POST['username']);
		$password = trim($_POST['password']);
		
		//validate username
		
			// check username and password in database
			if(!isValidLogin($username, $password, $connection)){
				// смислено за потребителя съобщение за грешка
				echo '<h3>Грешна парола!<h3>';
			}
	
	}
}
include('include/footer.php');
?>


