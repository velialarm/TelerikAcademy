<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title><?php
echo $title;
?></title>

<link href="css/style.css" rel="stylesheet" type="text/css">
</head>

<body>
	<div id="content">
		<h1>
<?php
echo $title;
?>
<span class="well_user">
<?php
if ((isset ( $_SESSION ['username'] ))) {
	echo 'Wellcome ' . strtoupper ( $_SESSION ['username'] );
}
?>
</span>
		</h1>
<?php
include ('include/menu.php');
?>
<div id="clear" />