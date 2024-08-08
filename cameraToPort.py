import numpy as np
import cv2
import socket
import time
# from PIL import Image
# import io

UDP_IP = "127.0.0.1"
UDP_PORT = 5005


#print(cv2.getBuildInformation())

cap = cv2.VideoCapture("C://Users//Arise_student//Downloads//cameraToPort//vid1.mp4")
#cap = cv2.VideoCapture("vid1.mp4")

ret, frame = cap.read()
print(type(frame))

#sock.bind((UDP_IP, 8000))

a = True

while (cap.isOpened()):

    ret, frame = cap.read() 
    sock = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
    sock.connect((UDP_IP, UDP_PORT))
    
    #sock.bind((UDP_IP, UDP_PORT))
    print(np.array(frame).shape)


    if ret:
        #cv2.imshow('frame',frame)
        cv2.waitKey(1)

    d = frame.flatten()
    s = d.tobytes()
    print(type(s))
    print("yes: " + str(len(list(s))))

    if a:
        print("yes: " + str(list(s)[:10]))
        a = False
    # print(int.from_bytes(s, byteorder = 'big'))

    ip = socket.gethostbyname("localhost")

    # print(len(list(s[1*46080:(1+1)*49152])))

    sock.sendall(s)
    #answer = sock.recv(4096)
    #print("check",answer)

    ret, frame = cap.read()
    sock.close()
    time.sleep(1)
    break


    
cap.release()
cv2.destroyAllWindows()