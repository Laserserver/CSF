<?php

$surname=$_POST['surname'];
$name=$_POST['name'];
$secondname=$_POST['secondname'];
$city=$_POST['city'];
$det=$_POST['det'];
$height=$_POST['height'];
$weight=$_POST['weight'];
$univer=$_POST['univer'];
$sp=$_POST['sp'];
$ank=$_POST['ank'];
$file ='obb.txt';


if(empty($surname))
echo "<b>Вы не ввели фамилию<br/>";
else
if(empty($name))
echo "<b>Вы не ввели имя<br/>";
else
if(empty($secondname))
echo "<b>Вы не ввели отчество<br/>";
else
if(empty($city))
echo "<b>Вы не ввели город<br/>";
else
if(empty($height))
echo "<b>Вы не ввели рост<br/>";
else
if(empty($weight))
echo "<b>Вы не ввели вес<br/>";
else
if($univer=="pusto")
echo"<b>Вы не ответили на 8 вопрос<br/>";
else
if($sp=="pusto")
echo"<b>Вы не ответили на 9 вопрос<br/>";
else
if(empty($det))
echo"<b>Вы не указали о наличии/отсутствии детей<br/>";
else
if(empty($ank))
echo "<b>Вы не рассказали о себе<br/>";
else echo "<b>Анкетирование успешно завершено!!!!!<br/>";
{
		  if(file_exists($file))
		  {
		  $fp = fopen("obb.txt", "a");
  fwrite($fp,$_POST['surname'].PHP_EOL);
  fwrite($fp,$_POST['name'].PHP_EOL);
  fwrite($fp,$_POST['secondname'].PHP_EOL);
  fwrite($fp,$_POST['city'].PHP_EOL);
  fwrite($fp,$_POST['det'].PHP_EOL);
  fwrite($fp,$_POST['height'].PHP_EOL);
  fwrite($fp,$_POST['weight'].PHP_EOL);
  fwrite($fp,$_POST['univer'].PHP_EOL);
  fwrite($fp,$_POST['sp'].PHP_EOL);
  fwrite($fp,$_POST['ank'].PHP_EOL);



  
fclose($fp);
	  
	  
	  echo'Завершено';
		  }
		  else{echo'ошибка открытия файла!';}
	  } 

?>
