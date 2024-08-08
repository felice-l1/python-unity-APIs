import numpy as np
import cv2
import socket
from PIL import Image


UDP_IP = "127.0.0.1"
UDP_PORT = 5005

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)

    s.bind((UDP_IP, UDP_PORT))
    s.listen()
    
#possibly try a for loop
    while True:
        conn, addr = s.accept()
        data, addr = conn.recvfrom(2457600)
        print("first")
        # print(list(data))
        # newImg = Image.frombytes("L", 46080, data.astype(np.int8).tostring())
        frame = np.frombuffer(data, dtype=np.uint8)
        # img = cv2.imdecode(frame, cv2.IMREAD_COLOR)
        # cv2.imwrite('aaeee.png', img)
        # print(type(img))
        # print(type(data))
        # image = Image.open(io.BytesIO(data))
        # print(type(image))
        # print(frame.shape
        # print(frame[:1])
        # print("ha")
        print(frame.shape)
        frame = frame.reshape((640, 1280, 3))
        get_frame = frame.copy()
        get_frame[:,:,0] = frame[:,:,2]
        get_frame[:,:,2] = frame[:,:,0]
        
        print(frame.shape)
        print("stuck 1")
        im = Image.fromarray(get_frame)
        im.show()
        #cv2.imshow("Received Frame", frame) 
        print("stuck 2")
        #s.sendall(bytes("GOT", 'utf-8'))