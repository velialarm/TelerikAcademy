<?php

$pageTitle='Разход';
include 'include/header.php';

//echo date("d.m.Y", time());

if($_POST)
{
	$error = false;
	$name = $_POST['name'];
	$price = $_POST['price'];
	$selectedGroup = (int)$_POST['group'];
	
	//нормализация
	$name = str_replace('|','',$name);
	
	$price = str_replace('|','',$price);
	$price=preg_replace("#[,]#",".",$price); 
	$price=preg_replace("#(^[0-9]{1,3}$)#","$1.00",$price);   
	$pricecheckpattern	= "#^[0-9]{1,3}\.[0-9]*$#";
	if (preg_match($pricecheckpattern,$price)==0)  {
		$error= true;
		echo 'Enter Number Pleace';
		}
	
	//валидация на кода
	$currentDate = date("d.m.Y", time());
	
	
	if(!$error)
	{
		$result = $currentDate.' | '.$name.' | '.$price.' | '.$selectedGroup."\n";
		if(file_put_contents('data.txt',$result,FILE_APPEND))
		{
			echo 'Записа е успешно извършен';
		}
		else
		{
			echo 'Неуспешен запис';
		}
	}
}

?>
<div id=links>
<a href="index.php">Списък</a>
</div>
<form method="post">
<div>Име: <input type="text" name="name" /></div>
<div>Сума:<input type="text" name="price" /></div>
<div>Вид:<select name="group">
<?php
	foreach($groups as $key=>$value)
	{
		echo '<option value="'.$key.'">'.$value.'</option>';
	}
?>
	
</select>
</div>
<div><input type="submit" value="Запиши" /></div>
</form>
<?php
include 'include/footer.php';
?>