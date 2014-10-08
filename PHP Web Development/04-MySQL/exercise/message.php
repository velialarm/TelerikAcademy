<?php
$pageTitle = 'Съобщения';
include('include/header.php');
if($_SESSION['username']!=NULL){
	include('HTML/exit.html');
	?>
	<div id="mess_content">
	<div class="mess_tbl">
	<table cellpadding="0" cellspacing="0">
	  <tr id="mess_header">
		<td>Дата</td>
		<td>Име на потребителя</td>
		<td>Заглавие на съобщението</td>
		<td>Съдържание</td>
	  </tr>
	  <?php getMessage($connection); ?>
	</table>
	</div>
	<div id="mess_back_link">
	<a href="new_message.php">Ново съобщение</a></div>
	</div>
	
	<?php
}
else{
	header('Location: index.php');
}
include('include/footer.php');
?>
