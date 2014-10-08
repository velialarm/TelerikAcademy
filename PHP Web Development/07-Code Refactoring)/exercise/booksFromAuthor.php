<?php
$title = 'Книги от автор';
include ('admin/functions.php');
include ('include/header.php');

if ($_GET) {
	$author_id = $_GET ['author_id'];
	showBookFromAutors ( $author_id, $con );
} else {
	header ( 'Location: index.php' );
}
include ('include/footer.php');
?>