<?php
$tiltle = 'Автори';
include './inc/header.php';
?>
<a href="index.php">Списък</a>
<a href="add_book.php">Нова книга</a>
<form method="post" action="authors.php">
    Име: <input type="text" name="author_name" />
    <input type="submit" value="Добави" />    
</form>
<?php
if ($_POST) {
    $author_name = trim($_POST['author_name']);
    if (mb_strlen($author_name) < 2) {
        echo '<p>Невалидно име</p>';
    } else {
        $author_esc = mysqli_real_escape_string($db, $author_name);
        $q = mysqli_query($db, 'SELECT * FROM authors WHERE
        author_name="' . $author_esc . '"');
        if (mysqli_error($db)) {
            echo 'Грешка';
        }

        if (mysqli_num_rows($q) > 0) {
            echo 'Има такъв автор';
        } else {
            mysqli_query($db, 'INSERT INTO authors (author_name)
            VALUES("' . $author_esc . '")');
            if (mysqli_error($db)) {
                echo 'Грешка';
            } else {
                echo 'Успешен запис';
            }
        }
    }
}
$authors = getAuthors($db);
if ($authors===false) {
    echo 'Грешка';
}
?>
<table border='1'>
    <tr><th>Автор</th></tr>

    <?php
    foreach ($authors as $row) {
        echo '<tr><td>' . $row['author_name'] . '</td></tr>';
    }
    ?>


</table>

<?php
include './inc/footer.php';
?>
 
