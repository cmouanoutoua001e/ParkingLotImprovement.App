import cv2
#import pandas as pd

"""   MISC FUNCTIONS   """

def draw_spaces(array):
    
    image = cv2.imread('images/parking_lot.png')
    
    # TOP ROW
    for i in range(10):
        edit_top(image, i, array[i])
    
    # BOTTOM ROW
    
    # DEBUG
    cv2.imshow("Wow", image)
    cv2.waitKey(0)
    
def edit_top(image, index, is_open):
    
    """ RECTANGLE VARIABLES """
    left_x = 32
    right_x = 76
    red = (255, 0, 0)
    yellow = (255, 255, 0)
    blue = (0, 0, 255)
    thickness = 2
    
    if (is_open):
        color = blue
    else:
        color = red
    
    return cv2.rectangle(image, (left_x + (47 * index), 38), (right_x + (47 * index), 130), color, thickness)
    

""" DEBUG MAIN """

def main():
    
    data = [True, False, True, False, True, False, True, False, True, False, True, False, True, False]
    #df = pd.Dataframe(data, columns="availability")

    print("Running")
    draw_spaces(data)

    
if __name__ == "__main__":
    main()