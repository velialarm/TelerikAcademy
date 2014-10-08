<div id="but_top">
	<a href="index.php">Книги</a> <a href="new_book.php">Нова книга</a> <a
		href="new_autor.php">Нов автор</a>
</div>

<div id="log_bs">
	<div id="but_top">
<?php
if (! (isset ( $_SESSION ['username'] ))) {
	?>
	<a href="login.php">Вход</a> <a href="register.php">Регистрация</a>
	<?php
} else {
	?>
<a href="admin/destroy.php">Изход</a>
<?php
}
?>
</div>
</div>