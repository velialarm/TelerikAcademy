<?php 
//session_set_cookie_params(300,'/','localhost',false,true); // не работи за Chrome 
session_set_cookie_params('600');
session_start();
mb_internal_encoding('UTF-8');
include('admin/functions.php');
?>
<!DOCTYPE html>
<html lang="en">
<head>
<title><?=$pageTitle ?></title>	
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<link href="css/style.css" rel="stylesheet" type="text/css">
</head>
<body>
