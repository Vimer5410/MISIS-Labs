<?php
session_start();

//провека авторизации 
if (!isset($_SESSION['user_id'])) {
    header('Location: index.php?error=auth_required');
    exit;
}
?>
<!DOCTYPE html>
<html lang="ru">
<head>
    <meta charset="UTF-8">
    <title>Личный кабинет</title>
    <style>
        body { font-family: Arial, sans-serif; background: #f4f4f4; padding: 50px; text-align: center; }
        .container { background: #fff; padding: 40px; border-radius: 8px; box-shadow: 0 0 10px rgba(0,0,0,0.1); display: inline-block; }
        a { display: inline-block; margin-top: 20px; padding: 10px 20px; background: #dc3545; color: white; text-decoration: none; border-radius: 4px; }
        a:hover { background: #c82333; }
    </style>
</head>
<body>
    <div class="container">
        <h1>Добро пожаловать, <?= htmlspecialchars($_SESSION['login']) ?>!</h1>
        <p>Вы успешно авторизовались в системе.</p>
        <a href="logout.php">Выйти из системы</a>
    </div>
</body>
</html>