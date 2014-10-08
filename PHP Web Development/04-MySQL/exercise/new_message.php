<?php
$pageTitle = 'Потребителски вход';
include('include/header.php');
if($_SESSION['username']!=NULL){
	include('HTML/exit.html');
	include('HTML/new_message.html');
	if($_POST){
			$title = trim($_POST['title']);
			$message = trim($_POST['mess']);
			
			if(strlen($title) > 50)
			{
				echo '<h3>You enter more of 50 char for title</h3>';
				exit;
				
			}else if(strlen($message) > 250){
				echo '<h3>You  enter more of 250 char for content</h3>';
				exit;
			}
			sendMessage($title, $message, $connection);
	}
}
else{
	header('Location: index.php');
}
include('include/footer.php');
?>