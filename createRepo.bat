@echo off
::echo 初始化仓库...
::git init
echo 连接gitee...
git remote add all git@gitee.com:haceau/%1.git
echo 获取LICENSE（pull）...
git pull all master
echo 连接github...
git remote set-url --add all git@github.com:Haceau-Zoac/%1.git
echo 添加...
git add --all
echo 提交...
git commit -m "%2"
echo 上传...
git push all master
echo 结束。
pause