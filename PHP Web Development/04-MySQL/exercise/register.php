<?php

$pageTitle = 'Регистрация';
include('include/header.php');
include('HTML/register.html');
if($_POST){
	$username = trim($_POST['username']);
	$password1 = trim($_POST['pass1']);
	$password2= trim($_POST['pass2']);

	if(strlen($username) < 5)
	{
		echo '<h3>You must enter more of 5 char for username</h3>';
		exit;
	}else if(strlen($password1) < 5 )
	{
		echo '<h3>You must enter more of 5 char for password</h3>';
		exit;
	}else if(checkAvailibaleUsername($username, $connection))
		{
			echo '<h3>
		изберете друго име, такова вече съществува
		</h3>';
		exit;
		}
		else
		{
			
			if($password1 != $password2){
				echo '<h3>Your password is not equal</h3>';
				exit;
				}
				else
				{
					addUser($username, $password1, $connection);
				}
		}
	//$result = addUser($username, $password, $connection );
	//echo '<h1>'.$result.'</h1>';
}
include('include/footer.php');
?>
