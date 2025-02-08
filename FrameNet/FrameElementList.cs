using System.Collections.Generic;

namespace FrameNet;

public class FrameElementList
{
    private List<FrameElement> _frameElements;

    /**
     * Constructor of frame element list from a string. The frame elements for a word is a concatenated list of
     * frame element separated via '#' character.
     * @param frameElementList String consisting of frame elements separated with '#' character.
     */
    public FrameElementList(string frameElementList)
    {
        _frameElements = new List<FrameElement>();
        var items = frameElementList.Split("#");
        foreach (var item in items)
        {
            _frameElements.Add(new FrameElement(item));
        }
    }

    /**
     * Overloaded toString method to convert a frame element list to a string. Concatenates the string forms of all
     * frame element with '#' character.
     * @return String form of the frame element list.
     */
    public override string ToString()
    {
        if (_frameElements.Count == 0)
        {
            return "NONE";
        }
        else
        {
            var result = _frameElements[0].ToString();
            for (int i = 1; i < _frameElements.Count; i++)
            {
                result += "#" + _frameElements[i];
            }

            return result;
        }
    }

    /**
     * Replaces id's of predicates, which have previousId as synset id, with currentId.
     * @param previousId Previous id of the synset.
     * @param currentId Replacement id.
     */
    public void UpdateConnectedId(string previousId, string currentId)
    {
        foreach (var frameElement in _frameElements)
        {
            if (frameElement.GetId().Equals(previousId))
            {
                frameElement.SetId(currentId);
            }
        }
    }

    /**
     * Adds a predicate argument to the frame element list of this word.
     * @param predicateId Synset id of this predicate.
     */
    public void AddPredicate(string predicateId)
    {
        if (_frameElements.Count > 0 && _frameElements[0].GetFrameElementType().Equals("NONE"))
        {
            _frameElements.RemoveAt(0);
        }

        _frameElements.Add(new FrameElement("PREDICATE", "NONE", predicateId));
    }

    /**
     * Removes the predicate with the given predicate id.
     */
    public void RemovePredicate()
    {
        foreach (var frameElement in _frameElements)
        {
            if (frameElement.GetFrameElementType().Equals("PREDICATE"))
            {
                _frameElements.Remove(frameElement);
                break;
            }
        }
    }

    /**
     * Checks if one of the frame elements is a predicate.
     * @return True, if one of the frame elements is predicate; false otherwise.
     */
    public bool ContainsPredicate()
    {
        foreach (var frameElement in _frameElements)
        {
            if (frameElement.GetFrameElementType().Equals("PREDICATE"))
            {
                return true;
            }
        }

        return false;
    }

    /**
     * Checks if one of the frame element is a predicate with the given id.
     * @param predicateId Synset id to check.
     * @return True, if one of the frame element is predicate; false otherwise.
     */
    public bool ContainsPredicateWithId(string predicateId)
    {
        foreach (var frameElement in _frameElements)
        {
            if (frameElement.GetFrameElementType().Equals("PREDICATE") && frameElement.GetId().Equals(predicateId))
            {
                return true;
            }
        }

        return false;
    }

    /**
     * Returns the frame elements as an array list of strings.
     * @return Frame elements as an array list of strings.
     */
    public List<string> GetFrameElements()
    {
        var result = new List<string>();
        foreach (var frameElement in _frameElements)
        {
            result.Add(frameElement.ToString());
        }

        return result;
    }

    /**
     * Checks if the given argument with the given type and id exists or not.
     * @param frameElementType Type of the frame element to search for.
     * @param frame frame Name of the frame to search for
     * @param id Id of the frame element to search for.
     * @return True if the frame element exists, false otherwise.
     */
    public bool ContainsFrameElement(string frameElementType, string frame, string id)
    {
        foreach (var frameElement in _frameElements)
        {
            if (frameElement.GetFrameElementType().Equals(frameElementType) &&
                frameElement.GetFrame().Equals(frame) &&
                frameElement.GetId().Equals(id))
            {
                return true;
            }
        }

        return false;
    }
}