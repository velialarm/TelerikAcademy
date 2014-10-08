<?php
session_start();
$pageTitle = 'Files';
include 'include/header.php';
if($_SESSION['isLoged']!=true){
echo 'You must login!';
}
else{
		$dir    = 'uploaded';
		$files = scandir($dir);
		//echo '<pre>'.print_r($files,true).'</pre>';
		include 'include/choise.php';
		?> 
		<table width="80%" border="1" cellspacing="0" cellpadding="0">
		  <tr>
			<td>N</td>
			<td>Име на файла</td>
		  </tr>
		  <?php
		  $iterator = 0;
			foreach($files as $fileArrray){
				if($iterator>1){
					echo '<tr><td>'
					.($iterator-1).
					'</td><td>'
					// download link
					.'<a href="img/'
					.$fileArrray.
					'"download>'
					.$fileArrray.
					'</a>'.
					'</td></tr>';
				}
		  $iterator++;
				}
		  
		  ?>	
		</table>	
		<?php
}
include 'include/footer.php';
?>


