<?php
$title = "Книги и автори";
include('admin/functions.php');
include('include/header.php');
//main content
include('html/table_index.html');
showBookAndAutors($con);
include('include/footer.html');
?>