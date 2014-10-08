<?php
$title = "Книгa";
include ('admin/functions.php');
include ('include/header.php');
// main content
// include('html/table_index.html');

if ($_GET) {
	// echo '<pre>'.print_r($_GET,true).'</pre>';
	$book_id = $_GET ['book_id'];
	if ($_POST) {
		
		$text = $_POST ['com_text'];
		addComments ( $book_id, $text, $con );
	}
}

?>

<?php
$autors = getAuthorsAndBooks ( $book_id, $con );
// echo '<pre>оп: '.print_r($autors,true).'</pre>';
?>
<table width="100%" border="1" cellspacing="0" cellpadding="0">
	<tr>
		<th>N</th>
		<th>Коментар</th>
		<th>От</th>
		<th>Дата и час</th>
	</tr>
<?php
showComments ( $book_id, $con );
if ((isset ( $_SESSION ['username'] ))) {
	?>

<div id="comment_form">
		<h3 id="h_comm">Оставете коментар:</h3>
		<form method="post">
			<textarea name="com_text" cols="55" rows="7" id="comment_text"></textarea>
			<div id="b_comm">
				<input type="submit" value="Добави">
			</div>
		</form>
		</form>
<?php
} else {
	echo 'Log in to write comments';
}
include ('include/footer.php');
?>