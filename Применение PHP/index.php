<?php
// стартуем сессию (всегда перовй строкой)
session_start();

// если уже авторизован - кидаем в кабинет
if (isset($_SESSION['user_id'])) {
    header('Location: dashboard.php');
    exit;
}

//фейк бд, пароль у обоих 'password'
$users = [
    'admin' => [
        'id' => 1,
        'password_hash' => '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi'
    ],
    'user' => [
        'id' => 2,
        'password_hash' => '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi'
    ]
];

$error = '';

//обрабаотываем отправку формы
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $login = trim($_POST['login'] ?? '');
    $password = trim($_POST['password'] ?? '');

    //готовим папку и файл логво
    $dir = __DIR__ . '/logs';
    if (!is_dir($dir)) {
        mkdir($dir, 0777, true);
    }
    $file = $dir . '/auth.log';
    $time = date('Y-m-d H:i:s');

    if (empty($login) || empty($password)) {
        $error = 'Заполните все поля';
    } else {
        //сверяем логин и хеш пароля (аналог бкрипт в шарпахх)
        if (isset($users[$login]) && password_verify($password, $users[$login]['password_hash'])) {
            //сохраняем состояние в сессию
            $_SESSION['user_id'] = $users[$login]['id'];
            $_SESSION['login'] = $login;

            // пишем в лог усех и редиректим
            $line = "$time || user=$login | action=SUCCESS_LOGIN" . PHP_EOL;
            file_put_contents($file, $line, FILE_APPEND);

            header('Location: dashboard.php');
            exit;
        } else {
            //касяк с паролем — логируем ошибку
            $error = 'Неверный логин или пароль';
            $line = "$time || user=$login | action=FAIL_LOGIN" . PHP_EOL;
            file_put_contents($file, $line, FILE_APPEND);
        }
    }
}
?>
<!DOCTYPE html>
<html lang="ru">
<head>
    <meta charset="UTF-8">
    <title>Авторизация</title>
    <style>
        body { font-family: Arial, sans-serif; background: #f4f4f4; display: flex; justify-content: center; align-items: center; height: 100vh; margin: 0; }
        .form-container { background: #fff; padding: 30px; border-radius: 8px; box-shadow: 0 0 10px rgba(0,0,0,0.1); width: 300px; }
        h2 { margin-top: 0; text-align: center; color: #333; }
        input[type="text"], input[type="password"] { width: 100%; padding: 10px; margin: 10px 0; border: 1px solid #ccc; border-radius: 4px; box-sizing: border-box; }
        button { width: 100%; padding: 10px; background: #28a745; border: none; color: white; border-radius: 4px; cursor: pointer; font-size: 16px; }
        button:hover { background: #218838; }
        .error { color: red; text-align: center; margin-bottom: 10px; }
    </style>
</head>
<body>
    <div class="form-container">
        <h2>Вход в систему</h2>
        <?php if ($error): ?>
            <div class="error"><?= htmlspecialchars($error) ?></div>
        <?php endif; ?>
        <form method="POST">
            <input type="text" name="login" placeholder="Логин" required>
            <input type="password" name="password" placeholder="Пароль" required>
            <button type="submit">Войти</button>
        </form>
    </div>
</body>
</html>