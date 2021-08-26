# TransMe

长按鼠标中键（或自定义）划词翻译。代替 utools（竟然次数有限，用完永远不能再用，除非充钱）。

## 原理

通过模拟 Ctrl+C 复制（不要在运行中的终端使用！）。调用谷歌翻译，支持多行。

![image.png](https://ae03.alicdn.com/kf/He412da82d26e4da3adf49ea1f5eee7b85.png)

## 下载

去看 [Release](https://github.com/pluveto/TransMe/releases)

## 配置

可执行文件同目录下 `TransMe.dll.config` （没有可以新建）

```xml
<configuration>
  <appSettings>
    <add key="delay" value="500"/>
    <add key="button" value="middle"/>
  </appSettings>
</configuration>
```

+ `delay` 值为响应延迟。单位 ms.
+ `button` 为按键。支持：
  + left
  + middle
  + right
  + forward
  + back


由于基于 WIN32 API，所以暂时仅支持 Windows.
