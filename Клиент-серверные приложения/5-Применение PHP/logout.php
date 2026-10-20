<?php
session_start();

//логируем выход ели сессия еще жива
if (isset($_SESSION['login'])) {
    $login = $_SESSION['login'];
    $dir = __DIR__ . '/logs';
    $file = $dir . '/auth.log';
    $time = date('Y-m-d H:i:s');

    $line = "$time || user=$login | action=LOGOUT" . PHP_EOL;
    file_put_contents($file, $line, FILE_APPEND);
}

// дропаем сесию полнсотью
session_unset();
session_destroy();

header('Location: index.php');
exit;