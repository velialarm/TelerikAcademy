<?php
$title = 'Нова книга';
include('admin/functions.php');
include('include/header.php');
if($_POST){
	$book = trim($_POST['book_name']);
	if($book==null)
	{
		echo '<h2>Please add Book Name!</h2>';
		echo '<br/><a href="new_book.php">Back</a>';
		exit;
	}else if(mb_strlen($book)<3){
		echo '<h2>Please add Book Name with lenght more than 3 charachters</h2>';
		echo '<br/><a href="new_book.php">Back</a>';
		exit;
	}
	if(isset($_POST['select_autor'])){
		$autors = array($_POST['select_autor']);
	}
	else{
		$autors = null;
	}
	
	if(addBook($book, $autors, $con) == 1)
	{
		echo '<h2>Book '.$book.' was add.</h2>';
	}
}


include('html/book.html');
generateOption($con);
echo '</select><input id="inp_books_b" type="submit" value="Добави"></form></div>';
include('include/footer.html');
?>