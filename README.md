# VPNHelper
为Windows7批量配置VPN（PPTP），云梯VPN

1.主要工作原理
生成GUID
生成服务器名称和地址
PPTP和L2TP只是模板略有不同

生成的是
C:\Users\%UserName%\AppData\Roaming\Microsoft\Network\Connections\Pbk\rasphone.pbk的内容
所以如果有配置好的pbk文件也可以直接替换

2.注意
本程序不存贮用户名，密码以及密钥

#流程
1.生成内容
2.点Copy按钮复制内容
3.点打开目录
4.打开rasphone.pbk文件，将内容粘贴进文件
