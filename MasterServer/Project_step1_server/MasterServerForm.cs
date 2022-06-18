using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
namespace Project_step1_server
{
    public partial class ServerForm : Form
    {
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>(); //lIST FOR THE CLIENT SOCKETS
        List<string> clientNames = new List<string>(); //LIST FOR THE CLIENT NAMES TO GUARANTEE UNIQUENESS
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        bool connected = false;
        bool terminating = false;
        bool listening = false;
        string file_path;
        int maxNumClients = 16; //CAN BE CHANGED DEPENDING ON THE CURRENT EXPECTATIONS ON THE APPLICATION

        string pathForDB = "";
        string prevDB = ""; //IN ORDER TO MAINTAIN THE INFORMATION IN THE DATABASE

        DateTime now;

        public ServerForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;  //PREVENT THREAD ERRORS
            this.FormClosing += new FormClosingEventHandler(ServerForm_FormClosing); //FORM CLOSING METHOD IS ALSO IMPLEMENTED
            InitializeComponent();
        }
        
        //----------OPEN A FOLDER BROWSER TO SELECT A SAVING FOLDER-----------//
        private void browse_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.RootFolder = Environment.SpecialFolder.Desktop;
            browser.Description = "Select a folder to save the received files.";
            browser.ShowNewFolderButton = true;

            if (browser.ShowDialog() == DialogResult.OK)
                path_textBox.Text = browser.SelectedPath;
        }

        private void listen_button_Click(object sender, EventArgs e)
        {
            int serverPort;
            file_path = path_textBox.Text;
         
            //---------------CHECK IF PORT NUMBER AND FILEPATH IS PROVIDED CORRECTLY----------------//
            if (Int32.TryParse(port_textBox.Text, out serverPort) && (file_path != ""))
            {
                listening = true;

                //----------CREATE AN ENDPOINT OF GIVEN PORT AND IP TO BIND----------------------//
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                

                serverSocket.Bind(endPoint); //BIND
                serverSocket.Listen(maxNumClients); //PLACES SOCKETS IN THE LISTENING STATE, maxNumClients IS DEFINED GLOBALLY------//

                listen_button.Enabled = false;
                port_textBox.Enabled = false;
                path_textBox.Enabled = false;
                browse_button.Enabled = false;
                logs_richTextBox.Clear();
                
                logs_richTextBox.AppendText(DateTime.Now + " | Started listening port " + serverPort + ", files will be saved under folder " + file_path + ".\n");

                //--------DATABASE CREATION IF THIS IS THE FIRST TIME THAT THE SERVER IS EXECUTED, OTHERWISE THERE IS AN EXISTING DB--------//
                pathForDB = file_path + "\\DATABASE.txt";
                if (!File.Exists(@pathForDB))
                {
                    File.WriteAllText(@pathForDB, "Database is created\n\n");
                }


                bool connected = true;
                //--------START A THREAD FOR ACCEPTING NEW CLIENTS--------//
                Thread acceptThread = new Thread(AcceptPort);
                acceptThread.Start();       
            }

            else 
            {
                logs_richTextBox.AppendText("Please check the port number and folder path!\n");    
            }
        }


        private void AcceptPort()
        {
            while (listening)
            {           
                try
                {
                    Socket newClient = serverSocket.Accept(); //CREATE A SOCKET FOR NEWLY CREATED CONNECTION
                                
                    Byte[] name_buffer = new Byte[1024];
                    newClient.Receive(name_buffer); //RECEIVES THE NAME OF THE CLIENT 

                    string receivedName = Encoding.Default.GetString(name_buffer);           
                    receivedName = receivedName.Substring(0, receivedName.IndexOf("\0"));

                    //-----MESSAGE FOR THE VALIDITY OF THE USERNAME------------//
                    Byte[] usernameAckBuffer = new Byte[4];
                    string usernameAckMessage = "";

                    
                    clientSockets.Add(newClient);  //ADD THAT CLIENT TO OUR CLIENT LIST
                    clientNames.Add(receivedName);

                    logs_richTextBox.AppendText(DateTime.Now + receivedName + "> is connected now.\n");
                    logs_richTextBox.AppendText(DateTime.Now + " | Number of connected: " + clientNames.Count + "\n");

                        //-----INFORM THE CLIENT THAT THE USERNAME IS VALID, NO PROBLEMS WITH CONNECTION-------//
                        usernameAckMessage = "1";
                        usernameAckBuffer = Encoding.Default.GetBytes(usernameAckMessage);
                        newClient.Send(usernameAckBuffer);
                        
                        //-------START RECEIVING THE FILES FROM CLIENTS---------//
                        Thread receivedThread = new Thread(() => Receive(newClient,receivedName));
                        receivedThread.Start();

                        //-------THREAD FOR SENDING THE FILE LIST------------//
                        //Thread RetrieveFileListThread = new Thread(() => RetrieveFileList(newClient, receivedName, idxOfUser));
                        //RetrieveFileListThread.Start();
                              
                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        logs_richTextBox.AppendText("\n" + DateTime.Now + " | Socket stopped working.\n");
                        path_textBox.Enabled = true;
                        port_textBox.Enabled = true;
                        browse_button.Enabled = true;
                        listen_button.Enabled = true;
                        listening = false;
                    }
                }
            }
        }

        private void Receive(Socket thisClient , string clientName)
        {
            while (connected && !terminating)
            {
                try
                {
                    //----------------------------- RECEIVE FILE NAME OR COMMANDS ------------------------//
                    Byte[] file_name_buffer = new Byte[64];
                    thisClient.Receive(file_name_buffer);

                    string fileName = Encoding.Default.GetString(file_name_buffer);
                    fileName = fileName.Substring(0, fileName.IndexOf("\0"));


                    if(clientName =="Client" && fileName.StartsWith("file"))
                    { //THEN THE RECEIVED PIECE OF DATA FROM THE CLIENT IS NOT A COMMAND BUT THE FILENAME.
                        fileName = fileName.Remove(0, 4);
                        int idxOfDot = fileName.IndexOf(".");
                        fileName = fileName.Substring(0, idxOfDot);
                        fileName = clientName + "_" + fileName;

                        string save_fileName = "\\" + fileName + ".txt";
                        string write_path = file_path + save_fileName;
                        var path = @write_path;

                        prevDB = File.ReadAllText(@pathForDB);

                        string finalFileName;
                        bool txtExist;
                        if (File.Exists(path)) //CHECK IF THERE IS AN EXISTING FILE WITH USER PROVIDED FILENAME CURRENTLY, IF SO
                        {
                            logs_richTextBox.AppendText(DateTime.Now + " | Client <" + clientName + "> has already uploaded " + fileName + ".txt\n");

                            int counter = 1;
                            while (File.Exists(path)) //INCREMENT AND ADD THE NEXT NUMBER TO THE NAME OF THE FILE TO GUARANTEE UNIQUENESS
                            {
                                save_fileName = "";
                                save_fileName = "\\" + fileName + "(" + counter + ").txt";
                                write_path = file_path + save_fileName;
                                path = @write_path;
                                counter++;
                            }

                            string resultFileName = save_fileName.Substring(1, save_fileName.Length - 1);
                            logs_richTextBox.AppendText(DateTime.Now + " | File will be saved as:" + resultFileName + "\n");

                            //-------NEW FILE IS ADDED, DATABASE SHOULD BE UPDATED--------//
                            finalFileName = resultFileName;
                            txtExist = true;
                            
                        }
                        else //IF THERE IS NO EXISTING FILE WITH THAT NAME
                        {
                            logs_richTextBox.AppendText(DateTime.Now + " | Client <" + clientName + "> wants to upload a file, it will be saved as: " + fileName + ".txt\n");

                            txtExist = false;
                            finalFileName = fileName;
                            
                        }
                  

                        // ----------- GET THE NUMBER OF PACKETS -------------------------//
                        Byte[] packet_buffer = new Byte[8192];
                        thisClient.Receive(packet_buffer);

                        string packets = Encoding.Default.GetString(packet_buffer);
                        packets = packets.Substring(0, packets.IndexOf("\0"));

                        int packet_amount = Int32.Parse(packets);

                        //-------------------------- SEND ACKNOWLEDGEMENT ------------------//
                        Byte[] buffer = new Byte[8];
                        buffer = Encoding.Default.GetBytes("OK");
                        thisClient.Send(buffer);
                      

                        //-------------------------RECEIVE THE FILE SIZE---------------------//
                        Byte[] sizeBuffer = new Byte[100];
                        thisClient.Receive(sizeBuffer);
                        string sizeStr = Encoding.Default.GetString(sizeBuffer);
                        sizeStr = sizeStr.Substring(0, sizeStr.IndexOf("\0"));
                        logs_richTextBox.AppendText(DateTime.Now + " | Started to receive a file of size " + sizeStr + " | Packets = " + packet_amount + "\n");

                        //-------------------------- SEND ACKNOWLEDGEMENT ------------------//
                        Byte[] lastAck = new Byte[8];
                        lastAck = Encoding.Default.GetBytes("OK");
                        thisClient.Send(lastAck);

                        //-------------------UPDATE DATABASE--------------------------------//
                        if (txtExist)
                        {
                            prevDB += DateTime.Now + " | username: " + clientName + " | filename: " + finalFileName + " | size: " + sizeStr + " | *private\n";
                            File.WriteAllText(@pathForDB, prevDB);
                        }
                        else
                        {
                            prevDB += DateTime.Now + " | username: " + clientName + " | filename: " + finalFileName + ".txt | size: " + sizeStr + " | *private\n";
                            File.WriteAllText(@pathForDB, prevDB);
                        }
                        

                        // -------------------------- RECEIVE FILE DATA -----------------//
                        for (int i = 1; i <= packet_amount; i++)
                        {
                            Byte[] data_buffer = new Byte[8192];
                            thisClient.Receive(data_buffer);

                            string data_received = Encoding.Default.GetString(data_buffer);
                            if (data_received.Length == 8192)
                            {
                                data_received = data_received.Substring(0, data_received.Length);
                            }
                            else
                            {
                                data_received = data_received.Substring(0, data_received.IndexOf("\0"));
                            }
                                

                            File.AppendAllText(path, data_received);

                            Array.Clear(data_buffer, 0, data_buffer.Length);
                        }
                        logs_richTextBox.AppendText(DateTime.Now + " | File is received and added under folder: " + write_path + "\n");
                    }
                    
                    else if (fileName == "Serverdscnt")
                    {
                        logs_richTextBox.AppendText(DateTime.Now + " | Client <" + clientName + "> has disconnected.\n");
                        logs_richTextBox.AppendText(DateTime.Now + " | Number of connected clients: " + (clientNames.Count - 1) + "\n");
                    }
                    else if (clientName == "Server")
                    {
                        logs_richTextBox.AppendText(DateTime.Now + " Server bağlandı  " + "\n");
                    }
                    else if (clientName == "Client" && fileName == "dwn")
                    {
                        Download(thisClient, clientName);
                    }
                }
                catch
                {
                    if (!terminating)
                    {
                        logs_richTextBox.AppendText(DateTime.Now + " | Client <" + clientName + "> has disconnected.\n");
                        logs_richTextBox.AppendText(DateTime.Now + " | Number of connected clients: " + (clientNames.Count-1) + "\n");
                    }
                    thisClient.Close(); //CLOSE SOCKET CONNECTION AND RELEASE RESOURCES
                    clientSockets.Remove(thisClient); //REMOVE THAT CLIENT FROM OUR SOCKET AND NAME LIST
                    clientNames.Remove(clientName);
                    connected = false;
                }
            }
        }


        private void ServerForm_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listening = false;
            terminating = true;
            //Byte[] endingBuffer = Encoding.Default.GetBytes("-1");
            //for (int i = 0; i < clientSockets.Count(); i++)
            //{
            //    clientSockets[i].Send(endingBuffer);
            //    clientSockets[i].Close();
            //}
            Environment.Exit(0);
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {

            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = textBox_IP.Text;
            string Username = textBox_Username.Text;

            int portNum;
            if ((Int32.TryParse(textBox_ConnectPort.Text, out portNum)) && (textBox_IP.Text != "") && (Username != ""))
            {
                try
                {
                    clientSocket.Connect(IP, portNum);
                    Byte[] buffer = new Byte[64];
                    buffer = Encoding.Default.GetBytes(Username);
                    clientSocket.Send(buffer);

                    //----TAKE AN ACK ON THE USERNAME, IF THERE IS SUCH A USER IN THE SERVER, DON'T CONNECT-------//
                    Byte[] usernameAckBuffer = new byte[4];
                    clientSocket.Receive(usernameAckBuffer);
                    string usernameAck = Encoding.Default.GetString(usernameAckBuffer);
                    usernameAck = usernameAck.Substring(0, usernameAck.IndexOf("\0"));
                    
                    if(usernameAck != "1")
                    {
                        logs_richTextBox.AppendText("There is a client with username " + Username + "who is already connected. Try another username!\n");
                    }
                    else //SAFE TO CONNECT
                    {
                        button_disconnect.BackColor = Color.IndianRed;
                        button_Connect.BackColor = Color.DimGray;
                        textBox_ConnectPort.BackColor = Color.MediumSeaGreen;
                        textBox_IP.BackColor = Color.MediumSeaGreen;
                        textBox_Username.BackColor = Color.MediumSeaGreen;

                        button_Connect.Enabled = false;
                        button_disconnect.Enabled = true;
                        connected = true;
                        textBox_ConnectPort.Enabled = false;
                        textBox_IP.Enabled = false;
                        textBox_Username.Enabled = false;
                        button_disconnect.Enabled = true;

                        logs_richTextBox.AppendText("Connected to the server!\n");
                        
                    }
                    
                }
                catch
                {
                    logs_richTextBox.AppendText("Could not connect to the server!\n");
                }
            }
            else //THEN THE INPUTS ARE NOT APPROPRIATE
            {
                textBox_ConnectPort.BackColor = Color.IndianRed;
                textBox_IP.BackColor = Color.IndianRed;
                textBox_Username.BackColor = Color.IndianRed;
                logs_richTextBox.AppendText("Check the username, IP address and port number!\n");
            }
        }

        public void Download(Socket thisClient, string clientName)
        {
            if (!terminating)
            {
                try
                {
                    //----------------NAME OF THE FILE TO BE DOWNLOADED IS RECEIVED------------------------//
                    Byte[] fileNameBuffer = new Byte[100];
                    thisClient.Receive(fileNameBuffer);
                    string fileToDownload = Encoding.Default.GetString(fileNameBuffer);
                    fileToDownload = fileToDownload.Substring(0, fileToDownload.IndexOf("\0"));

                    logs_richTextBox.AppendText(DateTime.Now + " | User <" + clientName + "> wants to download his/her" + fileToDownload + "\n");

                    string fNameDB = clientName + "_" + fileToDownload; //THIS IS HOW THE FILE MIGHT APPEAR IN THE DATABASE

                    //----------------NECESSARY INITIALIZATIONS TO READ THE DATABASE LINE BY LINE---------------//
                    var lines = File.ReadLines(@pathForDB);
                    int lineNum = 0;
                    bool fileFound = false; //THERE IS SUCH A FILE UPLOADED BY THE REQUESTOR CLIENT

                    foreach (var line in lines)
                    {
                        lineNum++;
                        if (lineNum > 2) //WE START PROCESSING LINES AFTER THE 2ND BECAUSE FIRST TWO LINES OF THE DB ARE DUMMY LINES
                        {
                            //------------FILENAME OF THE CURRENT ENTRY IS EXTRACTED----------//
                            string fileNameExtracted = line.Substring(line.IndexOf("filename") + 10);
                            fileNameExtracted = fileNameExtracted.Substring(0, fileNameExtracted.IndexOf(".") + 4);

                            if (fileNameExtracted == fNameDB)
                            {
                                fileFound = true;
                                break;
                            }
                        }
                    }

                    Byte[] publicAckBuffer; //THIS BUFFER IS CREATED TO SEND A MESSAGE TO CLIENT SIDE ABOUT THE RESULT OF THE DOWNLOAD
                    if (fileFound) //DOWNLOAD WILL BE SUCCESSFUL
                    {
                        logs_richTextBox.AppendText(DateTime.Now + " | There is a file " + fileToDownload + " in the database uploaded by client <" + clientName + "> , download is available!\n");
                        publicAckBuffer = Encoding.Default.GetBytes("Downloading your file " + fileToDownload + " is allowed!\n");
                        thisClient.Send(publicAckBuffer);
                    }
                    else //THERE IS NO FILE AVAILABLE FOR THE DOWNLOAD
                    {
                        logs_richTextBox.AppendText(DateTime.Now + " | There is not " + fileToDownload + " in the database uploaded by client <" + clientName + ">!\n");
                        publicAckBuffer = Encoding.Default.GetBytes("You have not uploaded " + fileToDownload + ", can't download!\n");
                        thisClient.Send(publicAckBuffer);
                        return;
                    }

                    //IF WE DID NOT RETURN SO FAR, THEN EITHER THE CLIENT THAT MADE THE DOWNLOAD REQUEST UPLOADED SUCH A FILE BEFORE OR THE FILE IS UPLOADED BY ANYONE ELSE AND PUBLICISED
                    string storagePath = path_textBox.Text;
                    string pathAndFName = storagePath + "\\" + fNameDB;
                    string data = System.IO.File.ReadAllText(pathAndFName);
                    int dataLength = data.Length;


                    //---------DATA WILL BE SENT PACKET BY PACKET, EACH PACKET HAS 8192 BYTES-------------//
                    //---------CALCULATE THE NUMBER OF PACKETS------------//

                    int numOfPackets = dataLength / 8192; //DATA LENGTH WILL ALWAYS BE A MULTIPLE OF 8192, MIN 8192. THIS IS HOW WE RECEIVE THE UPLOADED ONES BEFORE
                    numOfPackets += 1;

                    //----------------SEND THE NUMBER OF PACKETS INFORMATION TO THE CLIENT---------------//
                    Byte[] num_of_packets = new Byte[8192];
                    num_of_packets = Encoding.Default.GetBytes(numOfPackets.ToString());
                    thisClient.Send(num_of_packets);

                    //-----------RECEIVE THE ACK OF CLIENT RECEIVED THE NUMBER OF PACKETS INFORMATION--------//
                    Byte[] usernameAckBuffer = new Byte[8];
                    thisClient.Receive(usernameAckBuffer);
                    Array.Clear(usernameAckBuffer, 0, usernameAckBuffer.Length);

                    //--------SENDING THE SIZE OF THE FILE IS UNNECESSARY BECAUSE CLIENT WONT STORE THAT IN ITS DB, DIRECTLY START SENDING THE PACKETS

                    int index = 0;
                    logs_richTextBox.AppendText(DateTime.Now + " | File is sending to client side...\n");

                    //-----SEND THE DATA PACKET BY PACKET IN A LOOP THAT ITERATES NUMBER OF PACKET TIMES-----------//
                    for (int i = 1; i <= numOfPackets; i++)
                    {
                        Byte[] data_packet = new Byte[8192];
                        string part;

                        if ((data.Length - (i - 1) * 8192) >= 8192)
                            part = data.Substring(index, 8192);

                        else
                            part = data.Substring(index, (data.Length - (i - 1) * 8192));

                        data_packet = Encoding.Default.GetBytes(part);
                        thisClient.Send(data_packet);
                        Array.Clear(data_packet, 0, data_packet.Length);

                        index += 8192;
                    }

                    //--------WHOLE DATA IS SENT WHEN THE LOOP TERMINATES-------------------//
                    logs_richTextBox.AppendText(DateTime.Now + " | File has been sent. \n");
                }
                catch
                {
                    logs_richTextBox.AppendText(DateTime.Now + " | Something went wrong while handling the download request!\n");
                }
            }
        }

        private void button_disconnect_Click(object sender, EventArgs e)
        {
            
                connected = false;
                clientSocket.Close();
                button_disconnect.Enabled = false;
                button_Connect.Enabled = true;
                textBox_IP.Enabled = true;
                textBox_Username.Enabled = true;
                button_disconnect.BackColor = Color.DimGray;
                button_Connect.BackColor = Color.MediumSeaGreen;
                textBox_IP.BackColor = Color.White;
                textBox_Username.BackColor = Color.White;

                logs_richTextBox.AppendText("Disconnected from server!\n");
            
        }
    }
}
