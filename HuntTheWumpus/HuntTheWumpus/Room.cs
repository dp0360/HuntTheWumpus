using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus
{
    class Room
    {
        private string roomNumber;
        private string adjacentRoomOne, adjacentRoomTwo, adjacentRoomThree;
        private string characteristicOfTheRoom;

        public Room()
        {
            RoomNumber = null;
            AdjacentRoomOne = null;
            AdjacentRoomTwo = null;
            AdjacentRoomThree = null;
            CharacteristicOfTheRoom = null;
        }

        public string RoomNumber
        {
            get
            {
                return roomNumber;
            }

            set
            {
                roomNumber = value;
            }
        }

        public string AdjacentRoomOne
        {
            get
            {
                return adjacentRoomOne;
            }
            set
            {
                adjacentRoomOne = value;
            }
        }

        public string AdjacentRoomTwo
        {
            get
            {
                return adjacentRoomTwo;
            }
            set
            {
                adjacentRoomTwo = value;
            }
        }

        public string AdjacentRoomThree
        {
            get
            {
                return adjacentRoomThree;
            }
            set
            {
                adjacentRoomThree = value;
            }
        }

        public string CharacteristicOfTheRoom
        {
            get
            {
                return characteristicOfTheRoom;
            }
            set
            {
                characteristicOfTheRoom = value;
            }
        }
    }
}
