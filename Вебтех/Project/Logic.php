<?php
$flag = true;
$name = $_POST['name']; 
$town = $_POST['town'];
$spec = $_POST['spec'];
$cunt = $_POST['cunt'];
$pros = $_POST['pros'];
$cons = $_POST['cons'];
$step = $_POST['step'];
$prof = $_POST['prof'];
$facu = $_POST['facu'];
$work = $_POST['work'];
$cont = $_POST['cont'];
$help = $_POST['help'];
$fine = $_POST['fine'];
$surn = $_POST['surn'];
$midn = $_POST['midn'];
$coun = $_POST['coun'];

if(empty($name)){
	echo "<b>Вы не ввели имя<br/>";
	$flag = false;
}
if(empty($surn)){
	echo "<b>Вы не ввели фамилию<br/>";
	$flag = false;
}
if(empty($coun)){
	echo "<b>Вы не ввели страну<br/>";
	$flag = false;
}
if(empty($town)){
	echo "<b>Вы не ввели город<br/>";
	$flag = false;
}
if(empty($spec)){
	echo "<b>Вы не ввели специальность<br/>";
	$flag = false;
}
if(empty($cunt)){
	echo "<b>Вы не ввели годы обучения<br/>";
	$flag = false;
}
if($step == 'empty'){
	echo "<b>Вы не выбрали степень образования<br/>";
	$flag = false;
}
if($prof == 'empty'){
	echo "<b>Вы не выбрали качество препадавания профпредметов<br/>";
	$flag = false;
}
if($facu == 'empty'){
	echo "<b>Вы не выбрали качество препадавания факпредметов<br/>";
	$flag = false;
}
if($work == 'empty'){
	echo "<b>Вы не указали занятость во время обучения<br/>";
	$flag = false;
}
if($cont == 'empty'){
	echo "<b>Вы не ответили на вопро продолжения<br/>";
	$flag = false;
}
if($help == 'empty'){
	echo "<b>Вы не ответили на вопрос о помощи<br/>";
	$flag = false;
}
if($fine == 'empty'){
	echo "<b>Вы не ответили на последний вопрос<br/>";
	$flag = false;
}
if ($flag){
	$file ='Ank.txt';
		$fp = fopen($file, "a");
		fwrite($fp, "Еще одна запись: \r\n");
		fwrite($fp,"Имя: ".$name."\r\n");
		fwrite($fp,"Фамилия: ".$surn."\r\n");
		fwrite($fp,"Отчество: ".$midn."\r\n");
		fwrite($fp,"Страна: ".$coun."\r\n");
		fwrite($fp,"Город: ".$town."\r\n");
		fwrite($fp,"Специальность: ".$spec."\r\n");
		fwrite($fp,"Годы обучения: ".$cunt."\r\n");
		fwrite($fp,"Что нравилось: ".$pros."\r\n");
		fwrite($fp,"Что не нравилось: ".$cons."\r\n");
		fwrite($fp,"Степень образования: ".$step."\r\n");
		fwrite($fp,"Отзыв о профильных: ".$prof."\r\n");
		fwrite($fp,"Отзыв о факультативных: ".$facu."\r\n");
		fwrite($fp,"Работал/а во время обучения: ".$work."\r\n");
		fwrite($fp,"Хочет ли еще учиться: ".$cont."\r\n");
		fwrite($fp,"Мнение о помощи ВУЗа: ".$help."\r\n");
		fwrite($fp,"Доволен/льна ли обучением: ".$fine."\r\n");
	echo "Сохранено, спасибо!";
	fclose($fp);
}
?>