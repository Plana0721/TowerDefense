# TowerDefense

一个用 Unity 2022.3 制作的 3D 塔防游戏（开发中）。

## 玩法

敌人沿路径向终点移动，路径旁的塔会自动锁定最近的敌人开火。
点击地面可以消耗金币建造新塔。敌人走到终点会扣除玩家生命，生命归零则游戏结束。

## 已实现

- 敌人沿路径点移动（waypoints 数组 + Vector3.MoveTowards，帧率无关）
- 塔自动检测范围内最近的敌人（Physics.OverlapSphere）
- 塔转向目标、定时开火
- 子弹发射 → 追踪目标 → 命中扣血 → 销毁
- 敌人血量、受伤、死亡
- 波次生成（Prefab + Instantiate + 运行时注入路径点）
- 玩家生命值、漏怪扣血、Game Over 暂停
- 金币系统：击杀获得金币，UI 实时显示
- 点击地面建塔（Physics.Raycast + 经济系统扣费）
- 路径可视化（LineRenderer）

## 操作

- **鼠标左键**：点击地面建造塔（消耗金币）
- 塔会自动索敌、转向、开火

## 运行方式

1. 安装 Unity 2022.3 LTS
2. 用 Unity Hub 打开本项目
3. 打开 `Assets/Scenes/Main.unity`
4. 点 Play

## 关键技术点

- 单例模式（PlayerHealth.Instance / EconomyManager.Instance）
- 预制体实例化 + 运行时依赖注入（解决预制体不能引用场景对象的问题）
- 射线检测（Physics.Raycast）实现鼠标点击建塔
- 球形范围检测（Physics.OverlapSphere）选择最近目标
- LineRenderer 路径可视化
- FixedUpdate / Time.deltaTime 保证移动与逻辑帧率无关

## 开发日志

- 10-28 项目初始化，敌人沿路径移动
- 10-30 添加血量 UI
- 10-31 多波次循环、Game Over 判定、金钱系统
- 11-02 点击建塔（射线检测）
- 11-06 路径可视化（LineRenderer）
- 11-08 子弹发射与命中伤害
