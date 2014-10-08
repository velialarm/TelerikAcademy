<?php
$title = "Регистрация";
include ('admin/functions.php');
include ('include/header.php');
// main content
if (! (isset ( $_SESSION ['username'] ))) {
	if ($_POST) {
		// echo '<pre>'.print_r($_POST,true).'</pre>';
		$username = trim ( $_POST ['username'] );
		$password = trim ( $_POST ['pass'] );
		$pass_repeat = trim ( $_POST ['pass_repeat'] );
		if (strlen ( $username ) < 3) {
			echo 'Username must be more from 3 charackters';
			return;
		}
		if ($password != $pass_repeat) {
			echo 'not equal password in repeat field... ';
			return;
		}
		if (strlen ( $password ) < 3) {
			echo 'password must be more from 3 charackters';
			return;
		}
		// chek username
		if (checkExistuser ( $username, $con ) != 1) {
			echo 'Такова име вече съществува';
			return;
		} else {
			if (addUser ( $username, $password, $con )) {
				// echo 'Sucsesfull add user '.$username;
				header ( 'Location: index.php' );
			}
		}
	}
	?>
<div id="login_form">
	<form method="post">
		<div id="login_n">
			Потребителско име <input name="username" type="text">
		</div>

		<div id="login_n">
			Парола: <input name="pass" type="password">
		</div>
		<div id="login_n">
			Повторете паролата: <input name="pass_repeat" type="password">
		</div>
		<input name="" type="submit" value="Вход">
	</form>
</div>
<?php
} else {
	echo '<h3>' . $_SESSION ['username'] . ' You are register in system</h3>';
}
include ('include/footer.php');
?>