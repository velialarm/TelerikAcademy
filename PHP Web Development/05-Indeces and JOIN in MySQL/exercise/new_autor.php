<?php
$title = "Нов автор";
include('admin/functions.php');
include('include/header.php');

//echo '<pre>'.print_r($_POST,true).'</pre>';
if($_POST){
	$autor = trim($_POST['autor']);
	//Името на автора не трябва да е по-малко от 3 символа
	if(mb_strlen($autor)<3){
		echo '<h2>Autors lenght must be more than 3 charactars</h2>';
		echo '<a href="new_autor.php">Back</a>';
		exit;
	}
	if(addAutor($autor, $con) == 1)
	{
		echo '<h1>Autors was add to database</h1>';
	}
}

//main content
include('html/autor.html');
showAutors($con);
include('include/footer.html');
?>
