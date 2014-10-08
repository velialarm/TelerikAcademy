<?php
$title = "Вход";
include ('admin/functions.php');
include ('include/header.php');
// main content
if (! (isset ( $_SESSION ['username'] ))) {
	if ($_POST) {
		// echo '<pre>'.print_r($_POST,true).'</pre>';
		$username = trim ( $_POST ['username'] );
		$password = trim ( $_POST ['password'] );
		
		if (checkLogin ( $username, $password, $con )) {
			header ( 'Location: index.php' );
		} else {
			echo 'Wrong password or username';
		}
	}
	?>
<div id="login_form">
	<form method="post">
		<div id="login_n">
			Потребителско име: <input name="username" type="text">
		</div>
		<div id="login_p">
			Парола: <input name="password" type="password">
		</div>
		<input name="" type="submit" value="Вход">
	</form>
</div>
<?php
} else {
	echo '<h3>' . $_SESSION ['username'] . ' You are loged in</h3>';
}
include ('include/footer.php');
?>