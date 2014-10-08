<?php
session_start();
$pageTitle = 'Login';
include 'include/header.php';
$message = '';
echo $message;
//echo '<pre>'.print_r($_SESSION,true).'</pre>';
if($_SESSION['isLoged']!=true)
{
	if(count($_POST)>0){
		$username = trim($_POST['username']);
		$pasword = trim($_POST['pasword']);
		if($username== 'user' && $pasword=='qwerty'){
			$_SESSION['isLoged'] = true;			
			header("Location: files.php");
			exit;	
		}
		else
		{
			// Jump to login page
			$message = 'You must login!';
			header('Location: index.php');
			exit;
		}
	}
	?>
	<form method="post" >
	  <div> Име <input type="text" name="username"/></div>
	   <div> Парола<input type="password" name="pasword"/></div>
	   <div><input type="submit" value="Enter" /></div>
	</form>
<?php
}
include 'include/footer.php';
?>