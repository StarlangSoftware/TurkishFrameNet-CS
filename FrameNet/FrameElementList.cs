using System.Collections.Generic;

namespace FrameNet;

public class FrameElementList
{
    private List<FrameElement> _frameElements;
    
    /// <summary>
    /// Constructor of frame element list from a string. The frame elements for a word is a concatenated list of
    /// frame element separated via '#' character.
    /// </summary>
    /// <param name="frameElementList">String consisting of frame elements separated with '#' character.</param>
    public FrameElementList(string frameElementList)
    {
        _frameElements = new List<FrameElement>();
        var items = frameElementList.Split("#");
        foreach (var item in items)
        {
            _frameElements.Add(new FrameElement(item));
        }
    }
    
    /// <summary>
    /// Overloaded toString method to convert a frame element list to a string. Concatenates the string forms of all
    /// frame element with '#' character.
    /// </summary>
    /// <returns>String form of the frame element list.</returns>
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

    /// <summary>
    /// Replaces id's of predicates, which have previousId as synset id, with currentId.
    /// </summary>
    /// <param name="previousId">Previous id of the synset.</param>
    /// <param name="currentId">Replacement id.</param>
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

    /// <summary>
    /// Adds a predicate argument to the frame element list of this word.
    /// </summary>
    /// <param name="predicateId">Synset id of this predicate.</param>
    public void AddPredicate(string predicateId)
    {
        if (_frameElements.Count > 0 && _frameElements[0].GetFrameElementType().Equals("NONE"))
        {
            _frameElements.RemoveAt(0);
        }

        _frameElements.Add(new FrameElement("PREDICATE", "NONE", predicateId));
    }

    /// <summary>
    /// Removes the predicate with the given predicate id.
    /// </summary>
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

    /// <summary>
    /// Checks if one of the frame elements is a predicate.
    /// </summary>
    /// <returns>True, if one of the frame elements is predicate; false otherwise.</returns>
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

    /// <summary>
    /// Checks if one of the frame element is a predicate with the given id.
    /// </summary>
    /// <param name="predicateId">Synset id to check.</param>
    /// <returns>True, if one of the frame element is predicate; false otherwise.</returns>
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

    /// <summary>
    /// Returns the frame elements as an array list of strings.
    /// </summary>
    /// <returns>Frame elements as an array list of strings.</returns>
    public List<string> GetFrameElements()
    {
        var result = new List<string>();
        foreach (var frameElement in _frameElements)
        {
            result.Add(frameElement.ToString());
        }

        return result;
    }

    /// <summary>
    /// Checks if the given argument with the given type and id exists or not.
    /// </summary>
    /// <param name="frameElementType">Type of the frame element to search for.</param>
    /// <param name="frame">frame Name of the frame to search for</param>
    /// <param name="id">Id of the frame element to search for.</param>
    /// <returns>True if the frame element exists, false otherwise.</returns>
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