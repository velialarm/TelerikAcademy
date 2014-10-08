<?php
$pageTitle='Всички въведени до момента разходи';
include 'include/header.php';
$filter =0;
?>

<div id=links>
<a href="razhod.php">Добави нов разход</a>
</div>
<form method="post">
    <select name="filter_group">
        <option value="0">Всички</option>
        <?php
            foreach($groups as $key=>$value)
            {
                echo '<option value="'.$key.'">'.$value.'</option>';
            }
        ?>
        
    </select>
    <input type="submit" value="Филтрирай" />
</form>
<?php
 if($_POST){
	  $filter = (int)$_POST['filter_group'];
		  if($filter != 0){
				$choise = 'You choise filter: ';
			  	echo '<div id="message">'.$choise.$groups[$filter].'</div>';
		}
	}
?>
<table width="100%" border="1">
  <tr>
    <td>Дата</td>
    <td>Име</td>
    <td>Сума</td>
    <td>Вид</td>
  </tr>
  <?php
 
  
  
  	if(file_exists('data.txt'))
	{
		$result = file('data.txt');
		$sum = (float)0.0;
		foreach($result as $value)
		{
			$data = explode('|',$value);
			// филтър
			if($filter == trim($data[3]) || $filter ==0)
			{
				echo '
					   <tr>
						<td>'.$data[0].'</td>
						<td>'.$data[1].'</td>
						<td>'.$data[2].'</td>
						<td>'.$groups[trim($data[3])].'</td>
					  </tr>
				';
				$sum += $data[2];
			}
		}
	}
  ?>
   <tr>
    <td>...</td>
    <td>...</td>
    <td><?=$sum ?></td>
    <td>...</td>
  </tr>
</table>

<?php
include 'include/footer.php';
?>


