# RabbitMQ
消息队列的通用处理

RabbitMQ是一个消息代理。它的核心原理非常简单：接收和发送消息。

　　对于rabbitMQ本身的特点 参考官网 http://www.rabbitmq.com/features.html

　　1、可靠性(Reliability)
  
　　RabbitMQ提供很多特性供我们可以在性能和可靠性作出折中的选择，包括持久化、发送确认、发布者确认和高可用性等。
  
　　2、弹性选路(Flexible Routing)
  
　　消息在到达队列前通过交换（exchanges）来被选路。RabbitMQ为典型的选路逻辑设计了几个内置的交换类型。对于更加复杂的选路，我们可以将exchanges绑定在一起或者写属于自己的exchange类型插件。
  
　　3、集群化(Clustering)
  
　　在一个局域网内的几个RabbitMQ服务器可以集群起来，组成一个逻辑的代理人。
  
　　4、联盟(Federation)
  
　　对于那些需要比集群更加松散和非可靠连接的服务器来说，RabbitMQ提供一个联盟模型（Federation Model）
  
　　5、高可用队列(High Available Queue)
  
　　可以在一个集群里的几个机器里对队列做镜像，确保即时发生了硬件失效，你的消息也是安全的。
  
　　6、多客户端(Many Clients)
  
　　有各种语言的RabbitMQ客户端
  
　　7、管理UI(Management UI)
  
　　RabbitMQ提供一个易用的管理UI来监控和控制消息代理人的各个方面。
  
　　8、跟踪(Tracing)
  
　　如果你的消息系统行为异常，RabbitMQ提供跟踪支持来找出错误的根源。
  
　　9、插件系统(Plugin System)
  
　　RabbitMQ提供各种方式的插件扩展，我们可以实现自己的插件。
  

　　使用任务队列一个优点是能够轻易地并行处理任务。当处理大量积压的任务，只要增加工作队列，通过这个方式，能够实现轻易的缩放。
  
