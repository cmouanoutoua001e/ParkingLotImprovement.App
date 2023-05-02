import cv2
#import pandas as pd

"""   MISC FUNCTIONS   """

def draw_spaces(array):
    
    image = cv2.imread('images/parking_lot.png')
    
    """ Rectangle vars """
    left_x = 32
    right_x = 76
    red = (255, 0, 0)
    yellow = (255, 255, 0)
    blue = (0, 0, 255)
    thickness = 2
    
    # data[0]
    
    image = cv2.rectangle(image, (left_x, 38), (right_x, 130), red, thickness)
    
    # data[1]
    # data[2]
    # data[3]
    # data[4]
    # data[5]
    # data[6]
    # data[7]
    # data[8]
    # data[9]
    # data[10]
    # data[11]
    # data[12]
    # data[13]
    
    # DEBUG
    cv2.imshow("Wow", image)
    cv2.waitKey(0)
    
    

""" DEBUG MAIN """

def main():
    
    data = [True, False, True, False, True, False, True, False, True, False, True, False, True, False]
    #df = pd.Dataframe(data, columns="availability")

    print("Running")
    draw_spaces(data)

    
if __name__ == "__main__":
    main()