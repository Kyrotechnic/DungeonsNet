using System.Net.Sockets;
using Dungeons.Server.Api;
using Dungeons.Server.Entity;
using Dungeons.Server.Network;

namespace Dungeons.Server.User;

public class DungeonsUser : ServerInstance
{
    public TcpClient Client {get; private set;}
    public EntityPlayer Player;
    public NetworkStream Stream;
    public PacketMode PacketMode;
    public bool Disconnected;
    public int compressionThreshold;
    public DungeonsUser(TcpClient client)
    {
        this.Client = client;
        this.Disconnected = false;
        this.compressionThreshold = -1;
        this.Stream = Client.GetStream();
        this.PacketMode = PacketMode.Ping;

        this.Player = default!;

        new Task(StartListener).Start();
    }

    public void StartListener()
    {
        while (this.IsConnected())
        {
            try
            {
                while (!Stream.DataAvailable)
                {
                    if (!IsConnected())
                        break;
                    Thread.Sleep(2);
                }

                if (!IsConnected())
                    break;
                
                switch (IsCompressed())
                {
                    case true:
                        int pLength = Stream.ReadVarInt();
                        int dLength = Stream.ReadVarInt();
                        int realLength = pLength - dLength.GetVarIntBytes().Length;

                        if (dLength == 0)
                        {
                            ReadPacket(realLength);
                        }
                        else
                        {
                            ReadPacket(dLength);
                        }
                        break;
                    case false:
                        ReadPacket(Stream.ReadVarInt());
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        if (Player != null)
        {
            //save player thingies idk
        }

        Client.Close();
        server.ConnectionManager.RemoveUser(this);

        //this is to handle after the player is disconnected
    }

    public void ReadPacket(int length)
    {
        
    }

    public void Disconnect()
    {
        this.Disconnected = true;
    }

    public bool IsConnected()
    {
        return Client.Connected && !Disconnected;
    }

    public bool IsCompressed()
    {
        return server.ServerData.compression && PacketMode == PacketMode.Play;
    }
}