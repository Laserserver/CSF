<?php

$initials=$_POST['initials'];
$pol=$_POST['pol'];
$birth=$_POST['birth'];
$address=$_POST['address'];
$phonenumber=$_POST['phonenumber'];
$citizenship=$_POST['citizenship'];
$passport=$_POST['passport'];
$education=$_POST['education'];
$militaryduty=$_POST['militaryduty'];
$job=$_POST['job'];
$skills=$_POST['skills'];
$sp=$_POST['sp'];
$hobbie=$_POST['hobbie'];
$sroc=$_POST['sroc'];
$file ='ob.txt';


if(empty($initials))
echo "<b>Вы не указали ФИО<br/>";
else
if(empty($pol))
echo "<b>Вы не указали Ваш пол<br/>";
else
if(empty($birth))
echo "<b>Вы не указали год рождения<br/>";
else
if(empty($address))
echo "<b>Вы не указали Ваш адрес<br/>";
else
if(empty($phonenumber))
echo"<b>Вы не указали номер контактного телефона<br/>";
else
if(empty($citizenship))
echo"<b>Вы не указали Ваше гражданство<br/>";
else
if(empty($passport))
echo"<b>Вы не указали ваши паспортные данные<br/>";
else
if($education=="pusto")
echo"<b>Вы не ответили на 8 вопрос<br/>";
else
if($militaryduty=="pusto")
echo"<b>Вы не ответили на 9 вопрос<br/>";
else
if(empty($job))
echo"<b>Вы не указали Вашу предыдущую работу<br/>";
else
if(empty($skills))
echo"<b>Вы не указали Ваши навыки<br/>";
else
if($sp=="pusto")
echo"<b>Вы не ответили на 12 вопрос<br/>";
else
if(empty($hobbie))
echo"<b>Вы не указали Ваши хобби<br/>";
else
if($sroc=="pusto")
echo"<b>Вы не ответили на 14 вопрос<br/>";
else echo "<b>Анкетирование успешно завершено! Спасибо, что уделили нам время! Ожидайте нашего звонка.<br/>";
{
		  if(file_exists($file))
		  {
		  $fp = fopen("ob.txt", "a");
  fwrite($fp,$_POST['initials'].PHP_EOL);
  fwrite($fp,$_POST['pol'].PHP_EOL);
  fwrite($fp,$_POST['birth'].PHP_EOL);
  fwrite($fp,$_POST['address'].PHP_EOL);
  fwrite($fp,$_POST['phonenumber'].PHP_EOL);
  fwrite($fp,$_POST['citizenship'].PHP_EOL);
  fwrite($fp,$_POST['passport'].PHP_EOL);
  fwrite($fp,$_POST['education'].PHP_EOL);
  fwrite($fp,$_POST['militaryduty'].PHP_EOL);
  fwrite($fp,$_POST['job'].PHP_EOL);
  fwrite($fp,$_POST['skills'].PHP_EOL);
  fwrite($fp,$_POST['sp'].PHP_EOL);
  fwrite($fp,$_POST['hobbie'].PHP_EOL);
  fwrite($fp,$_POST['sroc'].PHP_EOL);


  
fclose($fp);
	  
	  
	  echo'Завершено';
		  }
		  else{echo'ошибка открытия файла!';}
	  } 

?>
