<?php
$title = 'Книги от автор';
include('admin/functions.php');
include('include/header.php');

if($_GET){
	echo '<div id="but_top"><a href="index.php">Книги</a></div>';
	$author_id = $_GET['author_id'];
	showBookFromAutors($author_id,$con);
	
}else
{
	header('Location: index.php');
}
include('include/footer.html');
?>